using System;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using Travel.Connectors.Hotel.Logger.Enum;
using Tavisca.Platform.Common.Logging;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Linq;
using Travel.Connectors.Hotel.Common;

namespace Travel.Connectors.Hotel.Logger
{
    public class FileLogger : ILogWriter
    {
        private readonly object _objectLock = new object();

        private void CreateLogFolders()
        {
            if (!Directory.Exists(Path.GetDirectoryName(ApplicationConstants.ExceptionLogsPath)))
                Directory.CreateDirectory(Path.GetDirectoryName(ApplicationConstants.ExceptionLogsPath));
            if (!Directory.Exists(ApplicationConstants.USGLogFilePath))
                Directory.CreateDirectory(ApplicationConstants.USGLogFilePath);
            if (!Directory.Exists(ApplicationConstants.SupplierLogFilePath))
                Directory.CreateDirectory(ApplicationConstants.SupplierLogFilePath);
            if (!Directory.Exists(ApplicationConstants.UnmappedErrorLogPath))
                Directory.CreateDirectory(ApplicationConstants.UnmappedErrorLogPath);
            if (!Directory.Exists(ApplicationConstants.ProfilerLogPath))
                Directory.CreateDirectory(ApplicationConstants.ProfilerLogPath);
        }

        public async Task WriteAsync(LogEntry entry)
        {
            CreateLogFolders();
            var logCategoryEnum = (LogCategory)System.Enum.Parse(typeof(LogCategory), entry.Category);

            switch (logCategoryEnum)
            {
                case LogCategory.USGTrace:
                    WriteTransactionLog(entry, logCategoryEnum, ApplicationConstants.USGLogFilePath);
                    break;
                case LogCategory.SupplierTrace:
                    WriteTransactionLog(entry, logCategoryEnum, ApplicationConstants.SupplierLogFilePath);
                    break;
                case LogCategory.UnMappedErrorTrace:
                    WriteTransactionLog(entry, logCategoryEnum, ApplicationConstants.UnmappedErrorLogPath);
                    break;
                case LogCategory.ProfilerTrace:
                    WriteTransactionLog(entry, logCategoryEnum, ApplicationConstants.ProfilerLogPath);
                    break;
                case LogCategory.ExceptionTrace:
                    WriteErrorLog((ErrorLogEntry)entry);
                    break;
                default:
                    WriteTransactionLog(entry, LogCategory.Default, ApplicationConstants.DefaultLogPath);
                    break;
            }
        }

        private void WriteTransactionLog(LogEntry entry, LogCategory logCategory, string folderPath)
        {
            if (logCategory.Equals(LogCategory.Default) && !Directory.Exists(ApplicationConstants.DefaultLogPath))
                    Directory.CreateDirectory(ApplicationConstants.DefaultLogPath);
            string jsonString = JsonConvert.SerializeObject(entry, Formatting.Indented, new StringEnumConverter());
            StringBuilder filePath = new StringBuilder();
            filePath.Append(folderPath);
            filePath.Append(logCategory);
            lock (_objectLock)
            {
                filePath.Append(DateTime.Now.ToString(ApplicationConstants.FileTimeStampFormat));
                filePath.Append((new Random()).Next(100, 999));
                filePath.Append(ApplicationConstants.LogFileExtension);
                File.WriteAllText(filePath.ToString(), jsonString);
            }
        }

        private void WriteErrorLog(ErrorLogEntry entry)
        {
            List<ErrorLogEntry> exceptionList = new List<ErrorLogEntry>();
            string jsonErrorLog = string.Empty;
            if (File.Exists(ApplicationConstants.ExceptionLogsPath))
            {
                string exceptionJson = File.ReadAllText(ApplicationConstants.ExceptionLogsPath);
                ErrorLogEntry[] resultList = JsonConvert.DeserializeObject<ErrorLogEntry[]>(exceptionJson);
                exceptionList = resultList.ToList();
                exceptionList.Add(entry);
                jsonErrorLog = JsonConvert.SerializeObject(exceptionList.ToArray(), Formatting.Indented, new StringEnumConverter());

                if (jsonErrorLog.Length >= ApplicationConstants.MaxSizeExceptionLogFile)
                {
                    CreateBackupFileIfMaxSizeExceeded();
                    exceptionList.Clear();
                    exceptionList.Add(entry);
                    jsonErrorLog = JsonConvert.SerializeObject(exceptionList.ToArray(), Formatting.Indented, new StringEnumConverter());
                }
            }
            else
            {
                exceptionList.Add(entry);
                jsonErrorLog = JsonConvert.SerializeObject(exceptionList.ToArray(), Formatting.Indented, new StringEnumConverter());
            }

            lock (_objectLock)
            {
                File.WriteAllText(ApplicationConstants.ExceptionLogsPath, jsonErrorLog);
            }
        }

        private void CreateBackupFileIfMaxSizeExceeded()
        {
            string exceptionLogfileName = ApplicationConstants.ExceptionLogsPath.Substring(0, ApplicationConstants.ExceptionLogsPath.Length - Path.GetExtension(ApplicationConstants.ExceptionLogsPath).Length);
            StringBuilder backupFileName = new StringBuilder();
            backupFileName.Append(exceptionLogfileName);
            backupFileName.Append(ApplicationConstants.BackupExceptionFileString);
            backupFileName.Append(DateTime.Now.ToString(ApplicationConstants.FileTimeStampFormat));
            backupFileName.Append(ApplicationConstants.LogFileExtension);
            File.Move(ApplicationConstants.ExceptionLogsPath, backupFileName.ToString());
            using (File.Create(ApplicationConstants.ExceptionLogsPath))
            {
            }
        }
    }
}

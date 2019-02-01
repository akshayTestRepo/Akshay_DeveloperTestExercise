using System;
using System.Configuration;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
namespace LogUtility
{
    public class Adapter
    {
        public string type { get; set; }
        private ILogger _logger;

        public Adapter(string type)
        {
            this.type = type;
        }

        public void Log(Exception ex)
        {
            switch (this.type)
            {
                case "FL":
                    _logger = new FileAdapter();
                    _logger.Log(ex);
                    break;

                case "DB":
                    _logger = new DatabaseAdapter();
                    _logger.Log(ex);
                    break;

                case "EV":
                    _logger = new EventLogAdapter();
                    _logger.Log(ex);
                    break;
                default:
                    break;
            }
        }
    }
}

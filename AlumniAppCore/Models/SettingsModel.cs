using System;
namespace AlumniAppCore.Models
{
    public class Settings
    {
        protected static Settings _settings;
        public AlumniConfig _conf;

        protected Settings()
        {
            this._conf = new AlumniConfig();
        }

        public static Settings GetInstance
        {
            get
            {
                if (_settings == null)
                {
                    _settings = new Settings();
                }
                return _settings;
            }
        }


    }
}

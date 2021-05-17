﻿
using System.ComponentModel;


namespace diary.Models.Wrappers
{
   public class GroupWrapper : IDataErrorInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string this[string columnName]
        {

            get
            {
                switch (columnName)
                {
                    case nameof(Id):
                        if (Id==0)
                      Error = "Pole Grupa jest wymagane";
                        else
                       Error = string.Empty;
                        break;
                    default:
                        break;
                }
                return Error;
            }
        }

        public bool IsValid
        {
            get
            {
                return string.IsNullOrWhiteSpace(Error);
            }

        }

        public string Error
        {
            get; set;
        }
    }
}


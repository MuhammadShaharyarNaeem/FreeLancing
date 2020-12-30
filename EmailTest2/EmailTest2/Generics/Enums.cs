﻿namespace EmailingProject.Generics
{
    public static class Enums
    {
        public enum LogType
        {
            Success = 0,
            Functional = 1,
            Info = 2,
            Sql = 3,
            Exception = 4
        };
        public enum QueryType
        {
            Reterieve = 1,
            NonQuery = 2,
            Scalar = 3
        }
        
    }
}

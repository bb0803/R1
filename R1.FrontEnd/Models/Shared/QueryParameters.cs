﻿namespace R1.FrontEnd.WA.Models.Shared
{
    public class QueryParameters
    {
        private int _pageSize = 15;
        public int StartIndex { get; set; }
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value;
            }
        }
    }
}

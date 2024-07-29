﻿using R1.FrontEnd.Web.Static;
using System.Security.AccessControl;

namespace R1.FrontEnd.Web.Models.API
{
    public class RequestDto
    {
        public StaticDescriptions.ApiType ApiType { get; set; } = StaticDescriptions.ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }

        public StaticDescriptions.ContentType ContentType { get; set; } = StaticDescriptions.ContentType.Json;
    }
}

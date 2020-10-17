﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.HTTP
{
    public class HttpResponse
    {
        public HttpResponse(string contentType, byte[] body, HttpStatusCode statusCode = HttpStatusCode.Ok)
        {
            if (body == null)
            {
                throw new ArgumentException(nameof(body));
            }

            this.StatusCode = statusCode;
            this.Body = body;
            this.Headers = new List<Header>()
            {
                { new Header("Content-Type", contentType) },
                { new Header("Conten-Lenght", body.Length.ToString())},
            };

            this.Cookies = new List<Cookie>();
        }
        public override string ToString()
        {
            var resposnseBuilder = new StringBuilder();
            resposnseBuilder.Append($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode.ToString()}" + HttpConstants.NewLine);
            foreach (var header in Headers)
            {
                resposnseBuilder.Append(header.ToString() + HttpConstants.NewLine);
            }

            foreach (var cookie in this.Cookies)
            {
                resposnseBuilder.Append($"Set-Cookie: " + cookie.ToString() + HttpConstants.NewLine);
            }
            resposnseBuilder.Append(HttpConstants.NewLine);

            return resposnseBuilder.ToString();
        }
        public HttpStatusCode StatusCode { get; set; }
        public ICollection <Header> Headers { get; set; }
        public ICollection<Cookie> Cookies { get; set; }
        public byte[] Body { get; set; }
    }
}

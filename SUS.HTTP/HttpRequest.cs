﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.HTTP
{
    public class HttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.Headers = new List<Header>();
            this.Cookies = new List<Cookie>();

            var lines = requestString.Split(new string[] { HttpConstants.NewLine },
                StringSplitOptions.None);

            var headerLine = lines[0];
            var headerLineParts = headerLine.Split(' ');

            this.Method = headerLineParts[0];
            this.Path = headerLineParts[1];

            int lineIndex = 1;
            bool isInHeaders = true;

            while (lineIndex < lines.Length)
            {
                var line = lines[lineIndex];
                lineIndex++;

                if (isInHeaders)
                {
                    this.Headers.Add(new Header(line));
                }
                else
                {
                    //read body
                }

                if (string.IsNullOrWhiteSpace(line))
                {
                    isInHeaders = false;
                    break;
                }

                
            }
        }

        public string Path { get; set; }

        public string Method { get; set; }
        
        public List<Header> Headers { get; set; }

        public List<Cookie> Cookies { get; set; }

        public string Body { get; set; }

    }
}

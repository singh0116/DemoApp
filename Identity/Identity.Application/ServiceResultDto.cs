using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Application
{
    /// <summary>
    /// Service result dto.
    /// </summary>
    /// <typeparam name="T"> Type of data.</typeparam>
    public class ServiceResultDto<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether a request got success.
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets Data.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Gets or sets Error.
        /// </summary>
        public string Error { get; set; }
    }
}

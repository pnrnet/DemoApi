// <copyright file="Response.cs" company="Demo Company">
// Copyright (c) Demo Company. All rights reserved.
// </copyright>
// <summary> Response message of the api.</summary>

namespace Demo.Dto.Responses
{
    using System.Net;

    /// <summary>
    /// Response : this class containt api's Response property.
    /// </summary>
    /// <typeparam name="TData">response object.</typeparam>
    public class Response<TData>
    {
        /// <summary>
        /// Gets or sets status.
        /// </summary>
        /// <value>
        /// Status.
        /// </value>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets http Status Code.
        /// </summary>
        /// <value>
        /// Http Status Code.
        /// </value>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Gets or sets data.
        /// </summary>
        /// <value>
        /// Data.
        /// </value>
        public TData Data { get; set; }

        /// <summary>
        /// Gets or sets errors.
        /// </summary>
        /// <value>
        /// Errors.
        /// </value>
        public object Errors { get; set; }
    }
}

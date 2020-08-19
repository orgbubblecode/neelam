﻿// -----------------------------------------------------------------------
// <copyright file="UpdateEntry.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.MethodCalls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Responses;
    using RestSharp;
    using SugarRestSharp.Helpers;

    /// <summary>
    /// Represents the UpdateEntry class
    /// </summary>
    internal static class UpdateEntry
    {
        /// <summary>
        /// Updates entry [SugarCrm REST method - set_entry]
        /// </summary>
        /// <param name="sessionId">Session identifier</param>
        /// <param name="url">REST API Url</param>
        /// <param name="moduleName">SugarCrm module name</param>
        /// <param name="entity">The entity object to update</param>
        /// <param name="selectFields">Selected field list</param>
        /// <returns>ReadEntryResponse object</returns>
        public static UpdateEntryResponse Run(string sessionId, string url, string moduleName, JObject entity, List<string> selectFields)
        {
            var updateEntryResponse = new UpdateEntryResponse();
            var content = string.Empty;

            try
            {
                dynamic data = new
                {
                    session = sessionId,
                    module_name = moduleName,
                    name_value_list = EntityToNameValueList(entity, selectFields)
                };

                var client = new RestClient(url);
                var request = new RestRequest(string.Empty, Method.POST);
                string jsonData = JsonConvert.SerializeObject(data);

                request.AddParameter("method", "set_entry");
                request.AddParameter("input_type", "json");
                request.AddParameter("response_type", "json");
                request.AddParameter("rest_data", jsonData);

                var sugarApiRestResponse = client.ExecuteEx(request);
                var response = sugarApiRestResponse.RestResponse;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    content = response.Content;
                    updateEntryResponse = JsonConverterHelper.Deserialize<UpdateEntryResponse>(content);
                    updateEntryResponse.StatusCode = response.StatusCode;
                }
                else
                {
                    updateEntryResponse.StatusCode = response.StatusCode;
                    updateEntryResponse.Error = ErrorResponse.Format(response);
                }

                updateEntryResponse.JsonRawRequest = sugarApiRestResponse.JsonRawRequest;
                updateEntryResponse.JsonRawResponse = sugarApiRestResponse.JsonRawResponse;
            }
            catch (Exception exception)
            {
                updateEntryResponse.StatusCode = HttpStatusCode.InternalServerError;
                updateEntryResponse.Error = ErrorResponse.Format(exception, content); 
            }

            return updateEntryResponse;
        }

        /// <summary>
        /// Format entity to json friendly dynamic object
        /// </summary>
        /// <param name="entity">The entity object to create</param>
        /// <param name="selectFields">Selected field list</param>
        /// <returns>List of name value as object</returns>
        public static Dictionary<string, object> EntityToNameValueList(JObject entity, List<string> selectFields)
        {
            var namevalueList = new Dictionary<string, object>();

            bool useSelectedFields = (selectFields != null) && (selectFields.Count > 0);
            var jproperties = entity.Properties().ToList();
            foreach (JProperty jproperty in jproperties)
            {
                string name = jproperty.Name;

                if (useSelectedFields)
                {
                    // The identifier must always be added.
                    if (string.Compare("id", name, StringComparison.CurrentCultureIgnoreCase) != 0)
                    {
                        if (selectFields.All(x => x.ToLower() != name.ToLower()))
                        {
                            continue;
                        }
                    }
                }

                object value = jproperty.Value;

                var namevalueDic = new Dictionary<string, object>();
                namevalueDic.Add("name", name);
                namevalueDic.Add("value", value);

                namevalueList.Add(name, namevalueDic);
            }

            return namevalueList;
        }
    }
}
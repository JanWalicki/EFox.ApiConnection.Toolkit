using System;
using System.Collections.Generic;

using System.Net.Http;
using System.Net.Http.Headers;



namespace EFox.ApiConnection.Toolkit
{
    public class Connection<T>
    {
        public HttpClient client = new HttpClient();
        public Connection(string? baseAdress)
        {
            client.BaseAddress = new Uri(baseAdress);
        }
        public Connection() { }


        /// <summary>
        ///     Add base adress to http client.
        /// </summary>
        /// <param name="url"> Key of header </param>
        public void AddBaseAdress(string url)
        {
            client.BaseAddress = new Uri(url);
        }


        /// <summary>
        ///     Add request header to http client.
        /// </summary>
        /// <param name="name"> Key of header </param>
        /// <param name="value"> Value of header </param>
        public void AddHeader(string name, string value)
        {
            client.DefaultRequestHeaders.Add(name, value);
        }







        /// <summary>
        ///     Send a GET request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="url"> Url to call </param>
        /// <returns>The task of type <typeparamref name="T"/> object representing the asynchronous operation. If respond is empty or not successful returns default(<typeparamref name="T"/>) </returns>
        public async Task<T> Get(string url)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        ///     Send a GET request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="url"> Url to call </param>
        /// <returns>The task of type List <typeparamref name="T"/> object representing the asynchronous operation. If respond is empty or not successful returns default(List <typeparamref name="T"/>) </returns>
        public async Task<List<T>> GetList(string url)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    List<T> data = await response.Content.ReadAsAsync<List<T>>();
                    return data;
                }
                else
                {
                    return default(List<T>);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        ///     Send a Post request to the specified Uri as an asynchronous operation as <typeparamref name="T"/> converted to JSON.
        /// </summary>
        /// <param name="url"> Url to call </param>
        /// <param name="data"> Data to post </param>
        /// <returns>The task of type bool object representing the asynchronous operation. If respond is successful returns true </returns>
        public async Task<HttpResponseMessage> Post(string url, T data)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsJsonAsync(url, data);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        /// <summary>
        ///     Send a Post request to the specified Uri as an asynchronous operation as List <typeparamref name="T"/> converted to JSON.
        /// </summary>
        /// <param name="url"> Url to call </param>
        /// <param name="data"> Data to post </param>
        /// <returns>The task of type bool object representing the asynchronous operation. If respond is successful returns true </returns>
        public async Task<HttpResponseMessage> PostList(string url, List<T> data)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsJsonAsync(url, data);
                return response;    
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        ///     Send a Post request to the specified Uri as an asynchronous operation as file converted to MultipartFormDataContent.
        /// </summary>
        /// <param name="url"> Url to call </param>
        /// <param name="data"> File to post </param>
        /// <returns>The task of type HttpResponseMessage object representing the asynchronous operation.</returns>
        public async Task<HttpResponseMessage> PostFile(string url, FileStream file, string contentType, string _name, string _fileName)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));

                var fileStreamContent = new StreamContent(file);
                fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);

                var data = new MultipartFormDataContent();
                data.Add(fileStreamContent, name: _name, fileName: _fileName);

                HttpResponseMessage response = await client.PostAsync(url, data);
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        /// <summary>
        ///     Send a Put request to the specified Uri as an asynchronous operation as <typeparamref name="T"/> converted to JSON.
        /// </summary>
        /// <param name="url"> Url to call </param>
        /// /// <param name="data"> Data to post </param>
        /// <returns>The task of type bool object representing the asynchronous operation. If respond is successful returns true </returns>
        public async Task<HttpResponseMessage> Put(string url, T data)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PutAsJsonAsync(url, data);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        /// <summary>
        ///     Send a Put request to the specified Uri as an asynchronous operation as List <typeparamref name="T"/> converted to JSON.
        /// </summary>
        /// <param name="url"> Url to call </param>
        /// <param name="data"> Data to post </param>
        /// <returns>The task of type bool object representing the asynchronous operation. If respond is successful returns true </returns>
        public async Task<HttpResponseMessage> PutList(string url, List<T> data)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PutAsJsonAsync(url, data);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        /// <summary>
        ///     Send a Put request to the specified Url as an asynchronous operation as file converted to MultipartFormDataContent.
        /// </summary>
        /// <param name="url"> Url to call </param>
        /// <param name="data"> File to post </param>
        /// <returns>The task of type HttpResponseMessage object representing the asynchronous operation.</returns>
        public async Task<HttpResponseMessage> PutFile(string url, FileStream file, string contentType, string _name, string _fileName)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));

                var fileStreamContent = new StreamContent(file);
                fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);

                var data = new MultipartFormDataContent();
                data.Add(fileStreamContent, name: _name, fileName: _fileName);

                HttpResponseMessage response = await client.PutAsync(url, data);
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        ///     Send a DELETE request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="url"> Url to call </param>
        /// <returns>The task of type bool object representing the asynchronous operation. If respond is successful returns true </returns>
        public async Task<HttpResponseMessage> Delete(string url)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.DeleteAsync(url);
            return response;
        }



    }



    public class Connection
    {
        public HttpClient client = new HttpClient();
        public Connection(string? baseAdress)
        {
            client.BaseAddress = new Uri(baseAdress);
        }
        public Connection() { }


        /// <summary>
        ///     Add base adress to http client.
        /// </summary>
        /// <param name="url"> Key of header </param>
        public void AddBaseAdress(string url)
        {
            client.BaseAddress = new Uri(url);
        }


        /// <summary>
        ///     Add request header to http client.
        /// </summary>
        /// <param name="name"> Key of header </param>
        /// <param name="value"> Value of header </param>
        public void AddHeader(string name, string value)
        {
            client.DefaultRequestHeaders.Add(name, value);
        }



        /// <summary>
        ///     Send a GET request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="url"> Url to call </param>
        /// <returns>The task of type <typeparamref name="T"/> object representing the asynchronous operation. If respond is empty or not successful returns default(<typeparamref name="T"/>) </returns>
        public async Task<T> Get<T>(string url)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        ///     Send a GET request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="url"> Url to call </param>
        /// <returns>The task of type List <typeparamref name="T"/> object representing the asynchronous operation. If respond is empty or not successful returns default(List <typeparamref name="T"/>) </returns>
        public async Task<List<T>> GetList<T>(string url)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    List<T> data = await response.Content.ReadAsAsync<List<T>>();
                    return data;
                }
                else
                {
                    return default(List<T>);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        ///     Send a Post request to the specified Uri as an asynchronous operation as <typeparamref name="T"/> converted to JSON.
        /// </summary>
        /// <param name="url"> Url to call </param>
        /// <param name="data"> Data to post </param>
        /// <returns>The task of type bool object representing the asynchronous operation. If respond is successful returns true </returns>
        public async Task<HttpResponseMessage> Post<T>(string url, T data)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsJsonAsync(url, data);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        /// <summary>
        ///     Send a Post request to the specified Uri as an asynchronous operation as List <typeparamref name="T"/> converted to JSON.
        /// </summary>
        /// <param name="url"> Url to call </param>
        /// <param name="data"> Data to post </param>
        /// <returns>The task of type bool object representing the asynchronous operation. If respond is successful returns true </returns>
        public async Task<HttpResponseMessage> PostList<T>(string url, List<T> data)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsJsonAsync(url, data);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        /// <summary>
        ///     Send a Post request to the specified Uri as an asynchronous operation as file converted to MultipartFormDataContent.
        /// </summary>
        /// <param name="url"> Url to call </param>
        /// <param name="data"> File to post </param>
        /// <returns>The task of type HttpResponseMessage object representing the asynchronous operation.</returns>
        public async Task<HttpResponseMessage> PostFile(string url, FileStream file, string contentType, string _name, string _fileName)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));

                var fileStreamContent = new StreamContent(file);
                fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);

                var data = new MultipartFormDataContent();
                data.Add(fileStreamContent, name: _name, fileName: _fileName);

                HttpResponseMessage response = await client.PostAsync(url, data);
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        /// <summary>
        ///     Send a Put request to the specified Uri as an asynchronous operation as <typeparamref name="T"/> converted to JSON.
        /// </summary>
        /// <param name="url"> Url to call </param>
        /// /// <param name="data"> Data to post </param>
        /// <returns>The task of type HttpResponseMessage object representing the asynchronous operation.</returns>
        public async Task<HttpResponseMessage> Put<T>(string url, T data)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PutAsJsonAsync(url, data);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        /// <summary>
        ///     Send a Put request to the specified Uri as an asynchronous operation as List <typeparamref name="T"/> converted to JSON.
        /// </summary>
        /// <param name="url"> Url to call </param>
        /// <param name="data"> Data to post </param>
        /// <returns>The task of type HttpResponseMessage object representing the asynchronous operation.</returns>
        public async Task<HttpResponseMessage> PutList<T>(string url, List<T> data)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PutAsJsonAsync(url, data);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        ///     Send a Put request to the specified Url as an asynchronous operation as file converted to MultipartFormDataContent.
        /// </summary>
        /// <param name="url"> Url to call </param>
        /// <param name="data"> File to post </param>
        /// <returns>The task of type HttpResponseMessage object representing the asynchronous operation.</returns>
        public async Task<HttpResponseMessage> PutFile(string url, FileStream file, string contentType, string _name, string _fileName)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));

                var fileStreamContent = new StreamContent(file);
                fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);

                var data = new MultipartFormDataContent();
                data.Add(fileStreamContent, name: _name, fileName: _fileName);

                HttpResponseMessage response = await client.PutAsync(url, data);
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        /// <summary>
        ///     Send a DELETE request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="url"> Url to call </param>
        /// <returns>The task of type HttpResponseMessage object representing the asynchronous operation.</returns>
        public async Task<HttpResponseMessage> Delete<T>(string url)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.DeleteAsync(url);
            return response;
        }



    }
}
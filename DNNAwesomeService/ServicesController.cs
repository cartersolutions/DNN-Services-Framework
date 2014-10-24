using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using DotNetNuke.Common;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Web.Api;

using DNNAwesomeService.Data;

namespace DNNAwesomeService
{
    [Authorize]
    public class ServicesController : DnnApiController
    {
        // Entities
        DNNAwesomeEntities _entities = DNNAwesomeEntities.Instance();

        public ServicesController()
        {
            this._entities.Configuration.ProxyCreationEnabled = false;
        }

        #region GET

        /// <summary>
        /// http://dnndev.me/DesktopModules/DNNAwesomeService/API/Services/GetCustomers
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public jQueryDataTableResponse GetCustomers(jQueryDataTableRequest request)
        {
            jQueryDataTableResponse response = new jQueryDataTableResponse();
            List<DNNAwesome_Customer> customers = new List<DNNAwesome_Customer>();

            try
            {
                var query  = this._entities.DNNAwesome_Customer.AsQueryable();

                if (request.sSearch != null)
                {
                    query = (from c in query
                             where c.Name.Contains(request.sSearch) ||
                             c.Address.Contains(request.sSearch) ||
                             c.City.Contains(request.sSearch) |
                             c.ZipCode.Contains(request.sSearch)
                             select c);                    
                }

                #region Sort
                switch (request.iSortCol_0)
                {
                    case 1:
                        if (request.sSortDir_0 != "desc")
                        {
                            query = query.OrderBy(c => c.CustomerID);
                        }
                        else
                        {
                            query = query.OrderByDescending(c => c.CustomerID);
                        }
                        break;
                    case 2:
                        if (request.sSortDir_0 != "desc")
                        {
                            query = query.OrderBy(c => c.Name);
                        }
                        else
                        {
                            query = query.OrderByDescending(c => c.Name);
                        }
                        break;
                    case 3:
                        if (request.sSortDir_0 != "desc")
                        {
                            query = query.OrderBy(c => c.Address);
                        }
                        else
                        {
                            query = query.OrderByDescending(c => c.Address);
                        }
                        break;
                    case 4:
                        if (request.sSortDir_0 != "desc")
                        {
                            query = query.OrderBy(c => c.City);
                        }
                        else
                        {
                            query = query.OrderByDescending(c => c.City);
                        }
                        break;
                    case 5:
                        if (request.sSortDir_0 != "desc")
                        {
                            query = query.OrderBy(c => c.ZipCode);
                        }
                        else
                        {
                            query = query.OrderByDescending(c => c.ZipCode);
                        }
                        break;
                }
                #endregion

                int totalRecords = query.Count();
                customers = query.Skip(request.iDisplayStart).Take(request.iDisplayLength).ToList();

                // Update response
                response.sEcho = request.sEcho;
                response.iTotalRecords = totalRecords;
                response.iTotalDisplayRecords = customers.Count;
                response.aaData = customers;

            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
            }

            return response;
        }
             
        /// <summary>
        /// http://dnndev.me/DesktopModules/DNNAwesomeService/API/Services/GetStatus 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public dynamic GetStatus()
        {
            try
            {
                // Get status and convert to Select2 friendly format. You probably want to create a view model for the status
                // and use the AutoMapper.
                var status = (from s in this._entities.DNNAwesome_Status select new { Text = s.Name, Value = s.StatusID }).ToList();
                
                if(status != null)
                {
                    return status;
                }
            }
            catch (Exception exc)
            {
                Exceptions.LogException(exc);
            }

            return new { Text = "No Status Found!", Value = "0" };
        }

        #endregion 

        #region POST

        /// <summary>
        /// http://dnndev.me/DesktopModules/DNNAwesomeService/API/Services/CreateCustomer
        /// </summary>
        /// <param name="customer">Customer data</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public string CreateCustomer(DNNAwesome_Customer customer)
        {
            string response = string.Empty;

            try
            {
                this._entities.DNNAwesome_Customer.Add(customer);
                this._entities.SaveChanges();
            }
            catch (Exception exc)
            {
                response = exc.Message;
                Exceptions.LogException(exc);
            }

            return response;
        }

        #endregion
    }
}

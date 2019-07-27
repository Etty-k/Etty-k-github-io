using FreeQueueServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FreeQueueServer.Controllers
{
    //functions of the store menu
    [RoutePrefix("api/Menu")]
    public class MenuController : ApiController
    {
        DB_freeQueueEntities DB = new DB_freeQueueEntities();

        /// <summary>
        /// convert product object from DTO object to SQL object
        /// </summary>
        /// <param name="product"></param>
        /// <returns>tbl_storesMenu</returns>
        public tbl_storesMenu ConvertFromDto(StoresMenuDTO product)
        {
            return new tbl_storesMenu()
            {
                Id = product.id,
                ProductName = product.productName,
                Store = product.store,
                ProductPrice = product.productPrice,
                ProductCategory = (product.productCategory != null) ? DB.tbl_productsCategories.FirstOrDefault(c => c.Category == product.productCategory).Id : 0,
                QuickProduct = product.quickProduct,
                PreperationTime = product.preperationTime,
                ProductImage = product.productImage,
                ProductStatus = product.productStatus
            };
        }

        /// <summary>
        /// convert MenuAddition object from DTO object to SQL object
        /// </summary>
        /// <param name="addittion"></param>
        /// <returns>tbl_storesMenu</returns>
        public tbl_menuAddittions ConvertAdditionFromDto(MenuAdditionsDTO addittion)
        {
            return new tbl_menuAddittions()
            {
                Id = addittion.id,
                Addition = addittion.additionName,
                AddtionPrice = addittion.additionPrice,
                AdditionImage = addittion.additionImage,
                AdditionStatus = addittion.additionStatus,
                Product = DB.tbl_storesMenu.FirstOrDefault(m=>m.ProductName==addittion.product).Id
            };
        }

        /// <summary>
        /// convert MenuAddition object from DTO object to SQL object
        /// </summary>
        /// <param name="addittion"></param>
        /// <returns>tbl_storesMenu</returns>
        public tbl_menuTastes ConvertTasteFromDto(MenuTastesDTO taste)
        {
            return new tbl_menuTastes()
            {
                Id = taste.id,
                Taste = taste.tasteName,
                TasteImage = taste.tasteImage,
                TasteStatus = taste.tasteStatus,
                Product = DB.tbl_storesMenu.FirstOrDefault(m => m.ProductName == taste.product).Id
            };
        }

        /// <summary>
        /// convert product object from DTO object to SQL object
        /// </summary>
        /// <param name="product"></param>
        /// <returns>tbl_storesMenu</returns>
        public tbl_storesMenu ConvertProductFromDto(StoresMenuDTO product)
        {
            return new tbl_storesMenu()
            {
                Id = product.id,
                ProductName = product.productName,
                Store = product.store,
                ProductPrice = product.productPrice,
                ProductCategory = (product.productCategory != null) ? DB.tbl_productsCategories.FirstOrDefault(c => c.Category == product.productCategory).Id : 0,
                QuickProduct = product.quickProduct,
                PreperationTime = product.preperationTime,
                ProductImage = product.productImage,
                ProductStatus = product.productStatus
            };
        }


        // GET: api/Menu
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Menu/5
        /// <summary>
        /// get store id and return the products of this store
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns>IHttpActionResult</returns>
        [Route("GetByStore/{storeId}")]
        public IHttpActionResult Get(int storeId)
        {
            return Ok(StoresMenuDTO.ConvertToDTO(DB.tbl_storesMenu.Where(m => m.Store == storeId).ToList()));
        }
        
        [Route("GetCategoriesByStore/{storeId}")]
        public IHttpActionResult GetCategories(int storeId)
        {
            //create a list with all the categories that belong to this store.
            var ls = ProductsCategoryDTO.ConvertToDTO(DB.tbl_productsCategories.ToList()).Where(c => DB.tbl_storesMenu.Where(m => m.Store == storeId && m.ProductCategory == c.id) != null);
            return Ok(ls);
        }

        [Route("GetStoreQuickProducts/{id}")]
        public IHttpActionResult GetQuickItems(int id)
        {
            return Ok(StoresMenuDTO.ConvertToDTO(DB.tbl_storesMenu.FirstOrDefault(m => m.Store == id && m.QuickProduct == true)));
        }


        /// <summary>
        /// pull out the menu additions list of the store
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns>IHttpActionResult</returns>
        [Route("GetAdditionsByStore/{storeId}")]
        public IHttpActionResult GetAdditions(int storeId)
        {
            return Ok(MenuAdditionsDTO.ConvertToDTO(DB.tbl_menuAddittions.Where(a => DB.tbl_storesMenu.Where(m =>m.Store==storeId && m.Id == a.Product) != null).ToList()));
        }

        /// <summary>
        /// pull out the menu tastes list of the store
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns>IHttpActionResult</returns>
        [Route("GetTastesByStore/{storeId}")]
        public IHttpActionResult GetTastes(int storeId)
        {
            return Ok(MenuTastesDTO.ConvertToDTO(DB.tbl_menuTastes.Where(t => DB.tbl_storesMenu.Where(m => m.Store == storeId && m.Id == t.Product) != null).ToList()));
        }

        // POST: api/Menu
        /// <summary>
        /// add product to DB
        /// </summary>
        /// <param name="product"></param>
        /// <returns>IHttpActionResult</returns>
        [Route("AddProduct")]
        public IHttpActionResult Post([FromBody]StoresMenuDTO product)
        {
            DB.tbl_storesMenu.Add(ConvertFromDto(product));
            DB.SaveChanges();
            return Ok(StoresMenuDTO.ConvertToDTO(DB.tbl_storesMenu.Where(m => m.Store == product.store).ToList()));
        }

        // POST: api/Menu
        /// <summary>
        /// add addition to DB
        /// </summary>
        /// <param name="addition"></param>
        /// <returns>IHttpActionResult</returns>
        [Route("AddAddition")]
        public IHttpActionResult Post([FromBody]MenuAdditionsDTO addition)
        {
            DB.tbl_menuAddittions.Add(ConvertAdditionFromDto(addition));
            DB.SaveChanges();
            var storeId = DB.tbl_storesMenu.FirstOrDefault(m => m.ProductName == addition.product).Store;
            return Ok(MenuAdditionsDTO.ConvertToDTO(DB.tbl_menuAddittions.Where(a => DB.tbl_storesMenu.Where(m => m.Store == storeId && m.Id == a.Product) != null).ToList()));
        }

        // POST: api/Menu
        /// <summary>
        /// add addition to DB
        /// </summary>
        /// <param name="taste"></param>
        /// <returns>IHttpActionResult</returns>
        [Route("AddAddition")]
        public IHttpActionResult Post([FromBody]MenuTastesDTO taste)
        {
            DB.tbl_menuTastes.Add(ConvertTasteFromDto(taste));
            DB.SaveChanges();
            var storeId = DB.tbl_storesMenu.FirstOrDefault(m => m.ProductName == taste.product).Store;
            return Ok(MenuAdditionsDTO.ConvertToDTO(DB.tbl_menuAddittions.Where(a => DB.tbl_storesMenu.Where(m => m.Store == storeId && m.Id == a.Product) != null).ToList()));
        }

        // PUT: api/Menu/5
        /// <summary>
        /// update product in DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        [Route("UpdateProduct/{id}")]
        public IHttpActionResult Put(int id, [FromBody]StoresMenuDTO product)
        {
            DB.Entry(ConvertFromDto(product)).State = System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();
            return Ok(StoresMenuDTO.ConvertToDTO(DB.tbl_storesMenu.Where(m => m.Store == product.store).ToList()));
        }

        // DELETE: api/Menu/5
        /// <summary>
        /// delete product from DB
        /// </summary>
        /// <param name="id"></param>
        [Route("DeleteProduct/{id}")]
        public IHttpActionResult Delete(int id)
        {
            var store = DB.tbl_storesMenu.FirstOrDefault(p => p.Id == id).Store;
            DB.tbl_storesMenu.Remove(DB.tbl_storesMenu.FirstOrDefault(m => m.Id == id));
            return Ok(StoresMenuDTO.ConvertToDTO(DB.tbl_storesMenu.Where(m => m.Store == store).ToList()));
        }
    }
}
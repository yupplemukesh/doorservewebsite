using Doorserve.Core.Dtos;
using DoorServe;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Doorserve.Core.Pages
{
   public class PageContentServices: IPageContentService
    {
        private readonly GlobalProperties db;
        public PageContentServices() => db = new GlobalProperties();

        public async  Task<List<PageContentModel>> GetPageContents(Guid CompId , int PageId)
        {

            var query = "GETPAGECONTENT";
            var sp = new List<SqlParameter>();
            var param = new SqlParameter("@PAGEID", PageId);
            sp.Add(param);
            param = new SqlParameter("@COMPID", CompId);
            sp.Add(param);
            return await Helper.RawSqlQuery<PageContentModel>(query, sp,
                x => new PageContentModel {
                    SectionName = x[0].ToString(),
                    Description = x[1].ToString(),
                    MetaTitle = x[2].ToString(),
                    MetaNameDescription = x[3].ToString(),
                }, db, "Procedure"
                );


        }
        public async Task<List<BannerModel>> GetPageBanners(Guid CompId, int PageId)
        {

            var query = "GETBANNERSBYPAGES";
            var sp = new List<SqlParameter>();
            var param = new SqlParameter("@PAGEID", PageId);
            sp.Add(param);
            param = new SqlParameter("@COMPID", CompId);
            sp.Add(param);
            return await Helper.RawSqlQuery<BannerModel>(query, sp,
                x => new BannerModel
                {
                    Name = x[0].ToString(),
                    SectionName = x[1].ToString(),
                    AltText = x[2].ToString(),
                    Description = x[3].ToString(),
                    HeaderTitle = x[4].ToString(),
                    BannerFileName = x[5].ToString(),
                    BannerLinkURL = x[6].ToString()
                }, db, "Procedure"
                );


        }
        private object ToDBNull(object value)
        {
            if (null != value)
                return value;
            return DBNull.Value;
        }
        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

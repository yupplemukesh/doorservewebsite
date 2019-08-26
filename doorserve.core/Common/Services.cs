using Doorserve.Core.Dtos;
using DoorServe;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;


namespace Doorserve.Core
{
    public class  Services: ICommonService
    {
        private readonly GlobalProperties  db;

       public Services()
        {
            db = new GlobalProperties();
        }

        public async Task<List<CategoryModel>>  GetCategories( Guid compId)
        {
            var query = "Select CatId CategoryId , CatName CategoryName from MSTCATEGORY where ISACTIVE=1 and companyId=@compId";
            var sp = new List<SqlParameter>();
            var param = new SqlParameter("@compId", compId);
            sp.Add(param);

            return await Helper.RawSqlQuery<CategoryModel>(query, sp,
                x => new CategoryModel { CategoryId = Convert.ToInt32( x[0]), CategoryName=x[1].ToString() }, db, "Query"
                );
        }

        public async Task<ContactDetails> GetConacts(Guid compId)
        {
            var query = "select companyName Name, ContactEmail Email, isnull(CustomerCareNumber,'') ContactNumber, CompanyAddress Address ,isnull( CompanyLogo,'') CompanyLogo,SocialLink from mstCompany where GUID=@compId";
            var sp = new List<SqlParameter>();
            var param = new SqlParameter("@compId", compId);
            sp.Add(param);
            var result=  await Helper.RawSqlQuery<ContactDetails>(query, sp,
                x => new ContactDetails {
                    Name = x[0].ToString(), Email = x[1].ToString()
                    ,
                    ContactNumber = x[2].ToString(),
                    Address= x[3].ToString(),                   
                    CompanyLogo = x[4].ToString(),
                    SocialLink = x[5].ToString(),
                }, db, "Query"
                );

            return result.FirstOrDefault() ; 
                
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

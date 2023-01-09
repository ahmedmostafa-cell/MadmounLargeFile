using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface WhoWeAreService
    {
        List<TbWhoWeAre> getAll();
        bool Add(TbWhoWeAre client);
        bool Edit(TbWhoWeAre client);
        bool Delete(TbWhoWeAre client);


    }
    public class ClsWhoWeAre : WhoWeAreService
    {
        MadmounDbContext ctx;

        public ClsWhoWeAre(MadmounDbContext context)
        {
            ctx = context;
        }
        public List<TbWhoWeAre> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbWhoWeAre> lstWhoWeAre = ctx.TbWhoWeAres.ToList();

            return lstWhoWeAre;
        }

        public bool Add(TbWhoWeAre item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.WhoWeAreId = Guid.NewGuid();
                ctx.TbWhoWeAres.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbWhoWeAre item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.Entry(item).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool Delete(TbWhoWeAre item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.Entry(item).State = EntityState.Deleted;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }
}

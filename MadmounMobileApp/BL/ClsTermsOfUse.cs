using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface TermsOfUseService
    {
        List<TbTermsOfUse> getAll();
        bool Add(TbTermsOfUse client);
        bool Edit(TbTermsOfUse client);
        bool Delete(TbTermsOfUse client);


    }
    public class ClsTermsOfUse : TermsOfUseService
    {
        MadmounDbContext ctx;

        public ClsTermsOfUse(MadmounDbContext context)
        {
            ctx = context;
        }
        public List<TbTermsOfUse> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbTermsOfUse> lstTermsOfUse = ctx.TbTermsOfUses.ToList();

            return lstTermsOfUse;
        }

        public bool Add(TbTermsOfUse item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.TermsOfUseId = Guid.NewGuid();
                ctx.TbTermsOfUses.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbTermsOfUse item)
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

        public bool Delete(TbTermsOfUse item)
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

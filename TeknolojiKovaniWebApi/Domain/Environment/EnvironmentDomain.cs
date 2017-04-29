using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknolojiKovaniWebApi.Domain.Environment
{
    public class EnvironmentDomain
    {
        internal void SaveEnvironment(DTOs.External.Environment environment)
        {
            tKovanContext ctx = new tKovanContext();
            TeknolojiKovaniWebApi.Models.EntityClass.Environment eEnvironment = new Models.EntityClass.Environment();
            eEnvironment.Name = environment.Name;
            eEnvironment.UserId = environment.UserId;
            ctx.Environment.Add(eEnvironment);
            ctx.SaveChanges();
        }
        internal void UpdateEnvironment(DTOs.External.Environment environment)
        {
            tKovanContext ctx = new tKovanContext();
            TeknolojiKovaniWebApi.Models.EntityClass.Environment eEnvironment = ctx.Environment.Single(x => x.Id == environment.Id);
            eEnvironment.Name = environment.Name;
            ctx.SaveChanges();
        }
        internal List<DTOs.External.Environment> GetAll(int UserId)
        {
            tKovanContext ctx = new tKovanContext();
            List<DTOs.External.Environment> lstEnvironment = ctx.Environment.Where(x => x.UserId == UserId).ToList().Select(x => new DTOs.External.Environment { Id = x.Id, Name = x.Name }).ToList();
            return lstEnvironment;
        }

        public bool DeleteEnvironment(int Id)
        {
            try
            {
                tKovanContext ctx = new tKovanContext();
                TeknolojiKovaniWebApi.Models.EntityClass.Environment Environment = ctx.Environment.Where(x => x.Id == Id).FirstOrDefault();
                ctx.Environment.Remove(Environment);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DTOs.External.Environment GetEnvironmentById(int Id)
        {
            tKovanContext ctx = new tKovanContext();
            TeknolojiKovaniWebApi.Models.EntityClass.Environment Environment = ctx.Environment.Where(x => x.Id == Id).FirstOrDefault();
            DTOs.External.Environment eEnvironment = new DTOs.External.Environment();
            eEnvironment = Utilities.Map<TeknolojiKovaniWebApi.Models.EntityClass.Environment, DTOs.External.Environment>(Environment, eEnvironment);
            return eEnvironment;
        }
    }
}

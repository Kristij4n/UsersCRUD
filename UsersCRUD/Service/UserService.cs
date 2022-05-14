using System;
using System.Collections.Generic;
using System.Linq;
using UsersCRUD.Database;
using UsersCRUD.Model;

namespace UsersCRUD.Service
{
    public class UserService
    {
        DBModel ObjContext;
        public UserService()
        {
            ObjContext = new DBModel();
        }

        #region GetAll/Read
        public List<UserDTO> GetAll()
        {
            List<UserDTO> ObjJobsList = new List<UserDTO>();
            try
            {
                var ObjQuery = from obj in ObjContext.Users
                               select obj;
                foreach (var job in ObjQuery)
                {
                    ObjJobsList.Add(new UserDTO
                    {                     
                        Id = job.Id,
                        Oib = (long)job.Oib,
                        Name = job.Name,
                        Surname = job.Surname,
                        City = job.City,
                        Address = job.Address,
                        Phone = (long)job.Phone,
                        Mail = job.Mail

                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjJobsList;
        }

        #endregion

        #region Add/Insert

        public bool Add(UserDTO objNewJob)
        {
            bool IsAdded = false;
            
            try
            {
                var ObjJob = new User();

                ObjJob.Id = objNewJob.Id;
                ObjJob.Oib = objNewJob.Oib;
                ObjJob.Name = objNewJob.Name;
                ObjJob.Surname = objNewJob.Surname;
                ObjJob.City = objNewJob.City;
                ObjJob.Address = objNewJob.Address;
                ObjJob.Phone = objNewJob.Phone;
                ObjJob.Mail = objNewJob.Mail;

                ObjContext.Users.Add(ObjJob);
                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsAdded = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return IsAdded;
        }

        #endregion

        #region Update

        public bool Update(UserDTO objJobToUpdate)
        {
            bool IsUpdated = false;

            try
            {

                var ObjJob = ObjContext.Users.Find(objJobToUpdate.Id);
                ObjJob.Oib = objJobToUpdate.Oib;
                ObjJob.Name = objJobToUpdate.Name;
                ObjJob.Surname = objJobToUpdate.Surname;
                ObjJob.City = objJobToUpdate.City;
                ObjJob.Address = objJobToUpdate.Address;
                ObjJob.Phone = objJobToUpdate.Phone;
                ObjJob.Mail = objJobToUpdate.Mail;

                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsUpdated = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return IsUpdated;
        }

        #endregion

        #region Delete

        public bool Delete(int id)
        {
            bool IsDeleted = false;
            try
            {
                var ObjJobToDelete = ObjContext.Users.Find(id);
                ObjContext.Users.Remove(ObjJobToDelete);
                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsDeleted = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsDeleted;
        }

        #endregion

        #region Search
        public UserDTO Search(int id)
        {
            UserDTO ObjJob = null;

            try
            {
                var ObjJobToFind = ObjContext.Users.Find(id);
                if (ObjJobToFind != null)
                {
                    ObjJob = new UserDTO()
                    {

                        Id = ObjJobToFind.Id,
                        Oib = (long)ObjJobToFind.Oib,
                        Name = ObjJobToFind.Name,
                        Surname = ObjJobToFind.Surname,
                        City = ObjJobToFind.City,
                        Address = ObjJobToFind.Address,
                        Phone = (long)ObjJobToFind.Phone,
                        Mail = ObjJobToFind.Mail
                    };

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjJob;
        }

        #endregion
    }
}


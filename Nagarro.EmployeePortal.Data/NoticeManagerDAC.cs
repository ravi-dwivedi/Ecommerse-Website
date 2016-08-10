using Nagarro.EmployeePortal.EntityDataModel.EntityModel;
using Nagarro.EmployeePortal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Nagarro.EmployeePortal.EntityDataModel;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Data.Objects.DataClasses;

namespace Nagarro.EmployeePortal.Data
{
    public class NoticeManagerDAC : DACBase, INoticeManagerDAC
    {
        public NoticeManagerDAC()
            : base(DACType.NoticeManagerDAC)
        {

        }

        public INoticeDTO GetNotice(int noticeId)
        {
            INoticeDTO noticeDTO = null;
            using (EmployeePortalEntities employeePortalEntities = new EmployeePortalEntities())
            {
                try
                {
                    var noticeEntity = employeePortalEntities.Notices.FirstOrDefault(notice => notice.NoticeId == noticeId);
                    if (noticeEntity != null)
                    {
                        noticeDTO = (INoticeDTO)DTOFactory.Instance.Create(DTOType.Notice);
                        
                        EntityConverter.FillDTOFromEntity(noticeEntity, noticeDTO);
                    }
                }
                catch (Exception ex)
                {
                    ExceptionManager.HandleException(ex);
                    throw new DACException(ex.Message, ex);
                }
            }
            return noticeDTO;
        }

        public IList<INoticeDTO> GetAllNotices()
        {
            IList<INoticeDTO> noticeDTOList = null;
            using (EmployeePortalEntities employeePortalEntities = new EmployeePortalEntities())
            {
                try
                {
                    var noticeEntityList = employeePortalEntities.Notices;
                    if (noticeEntityList != null)
                    {
                        noticeDTOList = new List<INoticeDTO>();

                        foreach(var notice in noticeEntityList)
                        {
                            INoticeDTO noticeDTO = (INoticeDTO)DTOFactory.Instance.Create(DTOType.Notice);
                            EntityConverter.FillDTOFromEntity(notice, noticeDTO);
                            noticeDTOList.Add(noticeDTO);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ExceptionManager.HandleException(ex);
                    throw new DACException(ex.Message, ex);
                }
            }
            return noticeDTOList;
        }

        public int InsertNotice(INoticeDTO noticeDTO)
        {
            int retVal = default(int);
            using(EmployeePortalEntities employeePortalEntities = new EmployeePortalEntities())
            {
                try
                {
                    Notice newNotice = new Notice();
                    //EntityConverter.FillEntityFromDTO(noticeDTO, newNotice);
                    newNotice.Title = noticeDTO.Title;
                    newNotice.Description = noticeDTO.Description;
                    newNotice.StartDate = noticeDTO.StartDate;
                    newNotice.ExpirationDate = noticeDTO.ExpirationDate;
                    newNotice.PostedBy = noticeDTO.PostedById;

                    Notice addedNotice = employeePortalEntities.Notices.Add(newNotice);
                    employeePortalEntities.SaveChanges();

                    retVal = addedNotice.NoticeId;
                }
                catch(Exception ex)
                {
                    ExceptionManager.HandleException(ex);
                    throw new DACException(ex.Message, ex);
                }
            }
            return retVal;
        }

        public bool UpdateNotice(INoticeDTO noticeDTO)
        {
            bool retVal = false;
            using (EmployeePortalEntities employeePortalEntities = new EmployeePortalEntities())
            {
                try
                {
                    var noticeEntity = employeePortalEntities.Notices.FirstOrDefault(notice => notice.NoticeId == noticeDTO.NoticeId);
                    if (noticeEntity != null)
                    {
                        noticeEntity.Title = noticeDTO.Title;
                        noticeEntity.Description = noticeDTO.Description;
                        noticeEntity.StartDate = noticeDTO.StartDate;
                        noticeEntity.ExpirationDate = noticeDTO.ExpirationDate;
                        employeePortalEntities.SaveChanges();
                        retVal = true;
                    }
                }
                catch (Exception ex)
                {
                    ExceptionManager.HandleException(ex);
                    throw new DACException(ex.Message, ex);
                }
            }
            return retVal;
        }
    }
}

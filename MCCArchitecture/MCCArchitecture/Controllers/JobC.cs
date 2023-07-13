using System;
using System.Collections.Generic;
using MCCArchitecture.Models;
using MCCArchitecture.Views;

namespace MCCArchitecture.Controllers
{
    public class JobC
    {
        private Job _jobModel;
        private VJob _jobView;

        public JobC(Job jobModel, VJob jobView)
        {
            _jobModel = jobModel;
            _jobView = jobView;
        }

        public void GetAll()
        {
            var result = _jobModel.GetAll();
            if (result.Count == 0)
            {
                _jobView.DataEmpty();
            }
            else
            {
                _jobView.GetAll(result);
            }
        }

        public void Insert()
        {
            var job = _jobView.InsertMenu();

            var result = _jobModel.Insert(job);
            switch (result)
            {
                case -1:
                    _jobView.Error();
                    break;
                case 0:
                    _jobView.Failure();
                    break;
                default:
                    _jobView.Success();
                    break;
            }
        }

        public void Update()
        {
            var job = _jobView.UpdateMenu();
            var result = _jobModel.Update(job);

            switch (result)
            {
                case -1:
                    _jobView.Error();
                    break;
                case 0:
                    _jobView.Failure();
                    break;
                default:
                    _jobView.Success();
                    break;
            }
        }

        public void SearchById()
        {
            string jobId = _jobView.GetJobId();
            var result = _jobModel.GetById(jobId);
            if (result == null)
            {
                _jobView.JobNotFound();
            }
            else
            {
                _jobView.GetById(result);
            }
        }

        public void Delete()
        {
            string jobId = _jobView.GetJobId();
            var result = _jobModel.Delete(jobId);
            switch (result)
            {
                case -1:
                    _jobView.Error();
                    break;
                case 0:
                    _jobView.Failure();
                    break;
                default:
                    _jobView.Success();
                    break;
            }
        }
    }
}

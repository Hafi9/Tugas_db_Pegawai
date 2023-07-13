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
            var jobId = _jobView.GetJobId();
            var job = _jobModel.GetById(jobId);
            if (job == null)
            {
                _jobView.JobNotFound();
                return;
            }

            var updatedJob = _jobView.UpdateMenu(job);

            var result = _jobModel.Update(updatedJob);
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

        public void Delete()
        {
            var jobId = _jobView.GetJobId();
            var job = _jobModel.GetById(jobId);
            if (job == null)
            {
                _jobView.JobNotFound();
                return;
            }

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
        public void SearchById()
        {
            var jobId = _jobView.GetJobId();
            var job = _jobModel.GetById(jobId);
            if (job == null)
            {
                _jobView.JobNotFound();
            }
            else
            {
                _jobView.GetById(job);
            }
        }
    }
}

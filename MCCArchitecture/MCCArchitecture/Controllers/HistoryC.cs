using MCCArchitecture.Models;
using MCCArchitecture.Views;
using System;

namespace MCCArchitecture.Controllers
{
    public class HistoryC
    {
        private History _historyModel;
        private VHistory _historyView;

        public HistoryC(History historyModel, VHistory historyView)
        {
            _historyModel = historyModel;
            _historyView = historyView;
        }

        public void GetAll()
        {
            var result = _historyModel.GetAll();
            if (result.Count == 0)
            {
                _historyView.DataEmpty();
            }
            else
            {
                _historyView.GetAll(result);
            }
        }

        public void Insert()
        {
            var history = _historyView.InsertMenu();

            var result = _historyModel.Insert(history);
            switch (result)
            {
                case -1:
                    _historyView.Error();
                    break;
                case 0:
                    _historyView.Failure();
                    break;
                default:
                    _historyView.Success();
                    break;
            }
        }

        public void Update()
        {
            var history = _historyView.UpdateMenu();
            var result = _historyModel.Update(history);

            switch (result)
            {
                case -1:
                    _historyView.Error();
                    break;
                case 0:
                    _historyView.Failure();
                    break;
                default:
                    _historyView.Success();
                    break;
            }
        }

        public void SearchByEmployeeId()
        {
            int employeeId = _historyView.GetEmployeeId();
            var result = _historyModel.GetByEmployeeId(employeeId);
            if (result == null)
            {
                _historyView.HistoryNotFound();
            }
            else
            {
                _historyView.GetById(result);
            }
        }

        public void Delete()
        {
            int employeeId = _historyView.GetEmployeeId();
            var result = _historyModel.Delete(employeeId);
            switch (result)
            {
                case -1:
                    _historyView.Error();
                    break;
                case 0:
                    _historyView.Failure();
                    break;
                default:
                    _historyView.Success();
                    break;
            }
        }
    }
}

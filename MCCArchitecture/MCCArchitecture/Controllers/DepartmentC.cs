using MCCArchitecture.Models;
using MCCArchitecture.Views;
using System;

namespace MCCArchitecture.Controllers
{
    public class DepartmentC
    {
        private Department _departmentModel;
        private VDepartment _departmentView;

        public DepartmentC(Department departmentModel, VDepartment departmentView)
        {
            _departmentModel = departmentModel;
            _departmentView = departmentView;
        }

        public void GetAll()
        {
            var result = _departmentModel.GetAll();
            if (result.Count == 0)
            {
                _departmentView.DataEmpty();
            }
            else
            {
                _departmentView.GetAll(result);
            }
        }

        public void Insert()
        {
            var department = _departmentView.InsertMenu();

            var result = _departmentModel.Insert(department);
            switch (result)
            {
                case -1:
                    _departmentView.Error();
                    break;
                case 0:
                    _departmentView.Failure();
                    break;
                default:
                    _departmentView.Success();
                    break;
            }
        }

        public void Update()
        {
            var department = _departmentView.UpdateMenu();
            var result = _departmentModel.Update(department);

            switch (result)
            {
                case -1:
                    _departmentView.Error();
                    break;
                case 0:
                    _departmentView.Failure();
                    break;
                default:
                    _departmentView.Success();
                    break;
            }
        }

        public void SearchById()
        {
            int id = _departmentView.GetDepartmentId();
            var result = _departmentModel.GetById(id);
            if (result == null)
            {
                _departmentView.DepartmentNotFound();
            }
            else
            {
                _departmentView.GetById(result);
            }
        }

        public void Delete()
        {
            int id = _departmentView.GetDepartmentId();
            var result = _departmentModel.Delete(id);
            switch (result)
            {
                case -1:
                    _departmentView.Error();
                    break;
                case 0:
                    _departmentView.Failure();
                    break;
                default:
                    _departmentView.Success();
                    break;
            }
        }
    }
}

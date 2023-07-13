using System;
using System.Collections.Generic;
using MCCArchitecture.Models;
using MCCArchitecture.Views;

namespace MCCArchitecture.Controllers
{
    public class EmployeeC
    {
        private Employee _employeeModel;
        private VEmployee _employeeView;

        public EmployeeC(Employee employeeModel, VEmployee employeeView)
        {
            _employeeModel = employeeModel;
            _employeeView = employeeView;
        }

        public void GetAll()
        {
            var result = _employeeModel.GetAll();
            if (result.Count == 0)
            {
                _employeeView.DataEmpty();
            }
            else
            {
                _employeeView.GetAll(result);
            }
        }

        public void Insert()
        {
            var employee = _employeeView.InsertMenu();

            var result = _employeeModel.Insert(employee);
            switch (result)
            {
                case -1:
                    _employeeView.Error();
                    break;
                case 0:
                    _employeeView.Failure();
                    break;
                default:
                    _employeeView.Success();
                    break;
            }
        }

        public void Update()
        {
            var employeeId = _employeeView.GetEmployeeId();
            var employee = _employeeModel.GetById(employeeId);
            if (employee == null)
            {
                _employeeView.EmployeeNotFound();
                return;
            }

            var updatedEmployee = _employeeView.UpdateMenu(employee);

            var result = _employeeModel.Update(updatedEmployee);
            switch (result)
            {
                case -1:
                    _employeeView.Error();
                    break;
                case 0:
                    _employeeView.Failure();
                    break;
                default:
                    _employeeView.Success();
                    break;
            }
        }

        public void Delete()
        {
            var employeeId = _employeeView.GetEmployeeId();
            var employee = _employeeModel.GetById(employeeId);
            if (employee == null)
            {
                _employeeView.EmployeeNotFound();
                return;
            }

            var result = _employeeModel.Delete(employeeId);
            switch (result)
            {
                case -1:
                    _employeeView.Error();
                    break;
                case 0:
                    _employeeView.Failure();
                    break;
                default:
                    _employeeView.Success();
                    break;
            }
        }

        public void SearchById()
        {
            var employeeId = _employeeView.GetEmployeeId();
            var employee = _employeeModel.GetById(employeeId);
            if (employee == null)
            {
                _employeeView.EmployeeNotFound();
            }
            else
            {
                _employeeView.GetById(employee);
            }
        }
    }
}

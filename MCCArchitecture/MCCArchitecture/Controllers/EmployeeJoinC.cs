using System;
using System.Collections.Generic;
using MCCArchitecture.Models;
using MCCArchitecture.Views;

namespace MCCArchitecture.Controllers
{
    public class EmployeeJoinC
    {
        private EmployeeJoin _employeeJoinModel;
        private VEmployeeJoin _employeeJoinView;

        public EmployeeJoinC(EmployeeJoin employeeJoinModel, VEmployeeJoin employeeJoinView)
        {
            _employeeJoinModel = employeeJoinModel;
            _employeeJoinView = employeeJoinView;
        }

        public void GetAll()
        {
            var result = _employeeJoinModel.GetAll();
            if (result.Count == 0)
            {
                _employeeJoinView.EmployeeNotFound();
            }
            else
            {
                _employeeJoinView.GetAll(result);
            }
        }
    }
}
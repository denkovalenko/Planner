/// <reference path="../App.js" />
/// <reference path="../../angular.js" />
PlannerApp.controller('timetableController', ['$scope', '$http', function ($scope, $http) {
    var me = this;
    me.departments = {};
    me.data = { scheduleList: {}, currentDev: {}, currentUser: {} };
    me.selectDep = function (dev) {
        me.departments.forEach(function (el) {
            if (el.Department.Id == dev) {
                me.data.scheduleList = el.Department.Schedule;
            }
        });

    };
    me.selectUser = function () {
        var iframe = document.getElementById("scheduleId");
        if (me.data.currentUser)
            iframe.src = "http://services.hneu.edu.ua:8081/schedule/schedule?employee=" + me.data.currentUser;
        else
            iframe.src = "http://services.hneu.edu.ua:8081/schedule/selection.jsf";
    };

    me.setAsDefault = function () {
        if (me.data.currentUser)
            $http.post('/Timetable/SetAsDefault', { Id: me.data.currentUser }).then(
                function (response) {
                    me.selectUser();
                }, function (response) {

                });
    };
    me.init = function () {
        $http.post('/Timetable/GetAllDepartments', {}).then(
            function (response) {
                me.departments = response.data.Departments;
                me.data.currentUser = response.data.Default;
                me.selectUser();
            }, function (response) {

            });
    };
    //$scope.GetDepartment = function () {
    //	$scope.departments = me.faculties.filter(function (element, index, array) {
    //		return element.Id == deptId;
    //	});
    //}
}]);
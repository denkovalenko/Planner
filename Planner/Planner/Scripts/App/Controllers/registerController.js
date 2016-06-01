/// <reference path="../App.js" />
/// <reference path="../../angular.js" />
PlannerApp.controller('registerController', ['$scope','$http', function ($scope,$http) {
	var me = this;

	$scope.faculties = [];
	$scope.departments = [];

	me.init = function () {
		$http.get('/Faculty/Get').then(
            function (response) {
            	$scope.faculties = response.data;
            }, function (response) {

            });
	};

	$scope.$watch('faculty', function (newVal) {
		if (newVal) {
			$scope.departments = [].filter.call($scope.faculties, function (element, index, array) {
				return element.Id == newVal;
			})[0].Departments;
		}
		else {
			$scope.departments = null;
		}
	});
}]);
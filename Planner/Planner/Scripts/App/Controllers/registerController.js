/// <reference path="../App.js" />
/// <reference path="../../angular.js" />
PlannerApp.controller('registerController', ['$scope', '$http', 'rolesFactory', function ($scope, $http, rolesFactory) {
	var me = this;
	$scope.rolesFactory = rolesFactory;

	$scope.faculties = [];
	$scope.departments = [];
    $scope.AcademicTitleEnum = "0";
    $scope.DegreeEnum = "0";
    $scope.PositionEnum = "0";
    $scope.roles = [];
    
	me.init = function () {
		$http.get('/Faculty/Get').then(
            function (response) {
            	$scope.faculties = response.data;
            }, function (response) {

            });
		$http.get('/Account/GetRoles').then(
            function (response) {
                $scope.roles = response.data;
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
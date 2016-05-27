/// <reference path="../App.js" />
/// <reference path="../../angular.js" />
PlannerApp.controller('departmentController', ['$scope', '$http', function ($scope, $http) {
	var me = this;

	$scope.departments = [];
	$scope.publications = [];

	me.init = function () {
		$http.get('/Department/Get').then(
            function (response) {
            	$scope.departments = response.data;
            }, function (response) {

            });
	};

	$scope.$watch('department', function (newVal) {
		if (newVal) {
			$http.get('/Department/Report?depId='+newVal.Id).then(
				function (response) {
				    $scope.publications = response.data;
				    console.log(response.data);
				}, function (response) {

				});
			//$scope.departments = [].filter.call($scope.faculties, function (element, index, array) {
			//	return element.Id == newVal;
			//})[0].Departments;
		}
		else {
			//$scope.departments = null;
		}
	});
}]);
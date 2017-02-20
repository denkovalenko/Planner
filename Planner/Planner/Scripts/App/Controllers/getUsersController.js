/// <reference path="../App.js" />
/// <reference path="../../angular.js" />
PlannerApp.controller('getUsersController',['$scope', '$http', function($scope, $http){
	var me = this;
	me.users = [];
	$scope.searchName = "";

	me.init = function () {
		$http.get('/Account/GetUsersData')
		.then(function (res) {
			me.users = res.data.UserList;
			
		}, function (err) {
			console.log(err);
		});
	};

}]);
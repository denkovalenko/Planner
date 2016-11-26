PlannerApp.controller('sidebarController', ['$scope', '$http','keeperService', function ($scope, $http,keeperService) {

    var me = this;
    $scope.serviceData = keeperService.data;
    me.init = function () {
        $http.get('/Account/GetUserInfo').then(
            function (response) {
                keeperService.data.user = response.data;
            }, function (response) {

            });
    };

   
}]);
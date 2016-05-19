PlannerApp.controller('mainController', ['$scope','$http', function ($scope,$http) {

    var me = this;
    $scope.isHide = 0;
    me.contributors = [];
    me.teachersList = [];
    me.init = function () {
        $http.get('/Author/Get').then(
            function (response) {
                // на всякий случай проверь что вернулось в response.data
                me.teachersList = response.data;
            }, function (response) {

            });
    }
    
    me.addContributors = function (id) { //Сделал через id а не index, потому что index будет менятся по фильтру а в самом массиве index элемента останется прежним
        for (var i = 0; i < me.teachersList.length; i++) {
            if (me.teachersList[i].UserId === id) {
                me.contributors.push(me.teachersList[i]);
                me.teachersList.splice(i, 1);
                break;
            }
        }
    }
    me.deleteFromContributors = function (index) {
        me.teachersList.push(me.contributors[index]);
        me.contributors.splice(index, 1);
    }
}]);
PlannerApp.controller('mainController', ['$scope','$http', 'validationFactory', function ($scope,$http, validationFactory) {

    var me = this;
    $scope.isHide = 0;
    me.collaborators = [];
    me.newCollaborators = [];
    me.teachersList = [];
    me.init = function () {
    	$http.get('/Author/Get').then(
            function (response) {
            	me.teachersList = response.data;
            }, function (response) {

            });
    };
    
    me.addCollaborators = function (id) { //Сделал через id а не index, потому что index будет менятся по фильтру а в самом массиве index элемента останется прежним
    	for (var i = 0; i < me.teachersList.length; i++) {
    		if (me.teachersList[i].UserId === id) {
    			me.collaborators.push(me.teachersList[i]);
    			me.teachersList.splice(i, 1);
    			break;
    		}
    	}
    	$scope.query = '';

    };

	me.addNewCollaborators = function (name) { //Сделал через id а не index, потому что index будет менятся по фильтру а в самом массиве index элемента останется прежним
		me.newCollaborators.push(name);
		$scope.query = '';

    }

    me.deleteFromCollaborators = function (index) {
        me.teachersList.push(me.collaborators[index]);
        me.collaborators.splice(index, 1);
    };

    me.deleteFromNewCollaborators = function (index) {
    	me.newCollaborators.splice(index, 1);
    };

    $scope.validators = validationFactory.getValidators();
    $scope.validationErrors = validationFactory.getValidationErrors();
    $scope.pattern = new RegExp("^[0-9]+$");
}]);

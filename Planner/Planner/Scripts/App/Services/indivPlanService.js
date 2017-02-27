PlannerApp.service('indivPlanService', function ($http) {
    var self = this;
    self.saveData = function (data) {
        var model = [];
        for (var el in data) {
            if (data != null) {
                model.push({ SchemaName: el, Value: data[el], Name: $scope.fieldFactory[el].name });
            }
        }
        $http.post('/IndividualPlan/SaveScientificData', { model: model }).then(
            function (response) {
                window.location.reload();
            }, function (response) {

            });
    }
    self.getData = function (type, next) {
        $http.post('/IndividualPlan/GetDataByType', { type: type }).then(
          function (response) {
              console.log(response.data);
             return next(response.data);
          }, function (response) {
          });
    }

});
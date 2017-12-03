PlannerApp.service('teacherservice', function ($http) {

    this.getAllTeachersRate = function () {
        return $http.get("/Distribution/AllTeachersRate");
    }
    this.getFactTeachersRate = function () {
        return $http.get("/Distribution/FactTeachersRate");
    }
    this.getFactTeachersRateId = function (Id) {
        return $http.get("/Distribution/GetFactTeachersRateById?Id=" + Id);
    }

    this.getAllTeachers = function () {
        return $http.get("/Distribution/GetTeachers");
    }
    this.getAllRates = function () {
        return $http.get("/Distribution/GetRates");
    }
    this.currentTeachersRate = function () {
        return $http.get("/Distribution/CurrentTeachersRate");
    }


    this.saveTeachersRate = function (TeacRate) {
        var save = $http({
            method: 'POST',
            url: '/Distribution/AddTeachersRate/',
            data: TeacRate
        });
        return save;
    }

    //this.getWareHouseId = function (WareHouseId) {
    //    return $http.get("/WareHouse/GetWareHouseById?WareHouseId=" + WareHouseId);
    //}

    this.editFactTeachersRate = function (TeacRate) {
        var save = $http({
            method: 'POST',
            url: '/Distribution/EditFactTeachersRate/',
            data: TeacRate
        });
        return save;
    }


    //this.editWareHouse = function (WareHouses) {
    //    var save = $http({
    //        method: 'POST',
    //        url: '/WareHouse/EditWareHouse/',
    //        data: WareHouses
    //    });
    //    return save;
    //}

    //this.deleteWareHouse = function (WareHouseId) {
    //    var deleterecord = $http({
    //        method: 'POST',
    //        url: "/WareHouse/DeleteWareHouse?WareHouseId=" + WareHouseId
    //    });
    //    return deleterecord;
    //}

    //this.getProducts = function () {
    //    return $http.get("/WareHouse/GetProducts");
    //}

});
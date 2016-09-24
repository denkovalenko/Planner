
PlannerApp.factory('validationFactory', function () {

    var factory = {};
    var stringLength = 4;

    factory.getValidators = function () {
        return {
            integer: new RegExp("^[0-9]+$"),
            string: new RegExp("^.{" + stringLength + ",}$"),
            float: new RegExp("^([0-9]*[.])?[0-9]+$")
        }

    }
    factory.getValidationErrors = function () {
        return {
            integer: "This is not an integer!",
            string: "String must be at least " + stringLength + " characters long!",
            float: "This is not a correct float value!",
            required: "This field is required!"

        }
    }
    return factory;
});

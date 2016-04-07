
var EmployeeInfo = function() {
    UIEngine.apply(this, arguments);
};
EmployeeInfo.prototype = Object.create(UIEngine.prototype);
EmployeeInfo.prototype.constructor = EmployeeInfo;

EmployeeInfo.prototype.getView = function() {

    this.tableSchema = {
        "firstName": {"title": "First Name", "type": "String", "filter": true, "class": 'uiinput' },
        "lastName": {"title": "Last Name", "type": "String"},
        "email": {"title": "Email", "type": "Number"},
    };

    return this.tableSchema;

}

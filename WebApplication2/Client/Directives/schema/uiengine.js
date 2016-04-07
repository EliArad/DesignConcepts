// One architecture is that all schema are handled in the angular as interface.
// The directive is responsible to create and present that schema on screen.

// Another options is where all schema are handled on the server side and the responsibility of changing the schema
// is syncrounize with the server person that can add field without letting the UI person about it or at least just
// Inform him.

var UIEngine = function() {
    if (this.constructor === UIEngine) {
        throw new Error("Can't instantiate abstract class!");
    }
    this.tableSchema = [];
};

UIEngine.prototype.getView = function() {
    throw new Error("Abstract method!");
}

var employeeInfo = function() {
    UIEngine.apply(this, arguments);
};
employeeInfo.prototype = Object.create(UIEngine.prototype);
employeeInfo.prototype.constructor = employeeInfo;

employeeInfo.prototype.getView = function () {

    this.tableSchema = {
        "firstName": { "title": "First Name", "type": "String", "filter": true, "class": 'uiinput' },
        "lastName": { "title": "Last Name", "type": "String" },
        "email": { "title": "Author", "type": "String", "readonly": true },
    };
}





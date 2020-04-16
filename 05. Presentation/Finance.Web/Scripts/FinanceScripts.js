function ThousandSeparatorToString(value) {

    if (value === null) {
        return "";
    }
    if (typeof value === 'undefined') {
        return "";
    }

    var newValue = value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, " ");
    return newValue;
}
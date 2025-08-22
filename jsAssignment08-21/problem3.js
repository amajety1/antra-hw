function checkEmailId(str) {
    str = str.toLowerCase();
    
    let atIndex = str.indexOf('@');
    let dotIndex = str.lastIndexOf('.');
    
    if (atIndex === -1 || dotIndex === -1) {
        return false;
    }
    
    if (atIndex < dotIndex && dotIndex - atIndex > 1) {
        return true;
    }
    
    return false;
}



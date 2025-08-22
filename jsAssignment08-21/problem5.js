let styles = ["James", "Brennie"];
styles.push("Robert");
let middleIndex = Math.floor(styles.length / 2);
styles[middleIndex] = "Calvin";
let removedFirst = styles.shift();
styles.unshift("Rose", "Regal");

let salaries = {
    John: 100,
    Ann: 160,
    Pete: 130
};

let sum = 0;
for (let key in salaries) {
    sum += salaries[key];
}

console.log("Sum of all salaries:", sum);

let sumAlternative = Object.values(salaries).reduce((total, salary) => total + salary, 0);
console.log("Sum using Object.values():", sumAlternative); 
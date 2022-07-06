let promiseRandom = () => {
    return new Promise((resolve, reject) => {
        setTimeout(() => resolve(Math.floor(Math.random() * 10) + 1), 3000);
        setTimeout(() => reject('I failed!'), 5000);
    }).then(alert);
}

let makeAllCaps = (arr) => {
    return new Promise((resolve, reject) => {
        resolve(arr.map(element => {
            return element.toUpperCase();
        }), arr);
        reject('this array is not contains only strings!')
    });
}

let sortWords = (arr) => {
    return new Promise((resolve, reject) => {
        resolve(makeAllCaps(arr).then(result => { result.sort(); return result; }),
            error => reject(error));
    });
}

let arr = ["ccc", "bbb", "aaa", "abc", "def", "ddd", "eee", "eff"];
sortWords(arr).then(data => console.log(data));

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

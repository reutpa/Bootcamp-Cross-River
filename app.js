let promiseRandom = () => {
    return new Promise((resolve, reject) => {
        setTimeout(() => resolve(Math.floor(Math.random() * 10) + 1), 3000);
        setTimeout(() => reject('I failed!'), 5000);
    }).then(alert);
}

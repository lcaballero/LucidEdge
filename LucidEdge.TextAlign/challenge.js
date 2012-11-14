function jsChallenge() {

	var num = 0;

	for (var i = 1; i < 1000; i++) {
		if (i % 5 != 0 && i % 7 != 0) {
			num += i;
		}
	}

	return num;
}

function jsChallenge2() {

	var num = 0, n = 1001;

	for (var i = 1; i < n; i++) {
		num += i;
	}

	return num;
}


function js1() {

	var num = 0, n = 1001, k = 5;

	for (var i = 0; i < n; i++) {

	}

	return num;
}

function js2() {
	var n = 1001;
	return (n * (n - 1)) / 2;
}

console.log( jsChallenge(), js1(), js2() );
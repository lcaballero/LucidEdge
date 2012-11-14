function guestChallenge() {

	var num = 0;

	for (var i = 0; i < 1001; i++) {

		var s = String(i);
		var b = (/7/g).test(s);

		if (!b) {
			num += i;
		}

	}

	return num;
};
一些链接：
	验证码链接
		[登陆]https://kyfw.12306.cn/otn/passcodeNew/getPassCodeNew?module=login&rand=sjrand

		[订票]https://kyfw.12306.cn/otn/passcodeNew/getPassCodeNew?module=passenger&rand=randp

		Get方式就行
	登陆链接
		https://kyfw.12306.cn/otn/login/loginAysnSuggest
		需要参数，使用Post方式，如下：
		loginUserDTO.user_name=用户名&userDTO.password=密码&randCode=验证码
	城市列表链接
		https://kyfw.12306.cn/otn/resources/js/framework/station_name.js?station_version=1.806
		Get方式就行
	乘客列表链接
		https://kyfw.12306.cn/otn/confirmPassenger/getPassengerDTOs
		Post方式，没有参数，但是要在登陆的之后才能获取
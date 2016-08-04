<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="errorPage.aspx.cs" Inherits="Team8_ADProjectLUStationerySystem.errorPage" %>

<!DOCTYPE html>
<html lang="en">

<head>
	<meta charset="utf-8">
	<title>Logic University Management System -  Error. Please try again. </title>

	<!-- Google Fonts -->
	<link href='https://fonts.googleapis.com/css?family=Roboto+Slab:400,100,300,700|Lato:400,100,300,700,900' rel='stylesheet' type='text/css'>

	<link rel="stylesheet" href="css/animate.css">
	<!-- Custom Stylesheet -->
	<link rel="stylesheet" href="css/style.css">

	<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>
</head>

<body>
    <form runat="server">
	<div class="container">
		<div class="top">
			<h1 id="title" class="hidden">Logic University Stationery System</h1>
		</div>
		<div class="login-box animated fadeInUp">
			<div class="box-header">
				<h2>Error</h2>
			</div>
			
			<label for="password">Your login credentials are inaccurate. Please try again.</label>
            <br />
            <br />
			<br/><br/>
			<%--<input type="password" id="password">--%>
            
			<%--<button type="submit" >Sign In</button>--%>
            <asp:Button ID="btnSubmit" runat="server" Text="Login" OnClick="btnSubmit_Click"/>
			<br/>
			<a href="#"><p class="small">&nbsp;</p></a>
		</div>
	</div>
    </form>
</body>

<script>
    $(document).ready(function () {
        $('#logo').addClass('animated fadeInDown');
        $("input:text:visible:first").focus();
    });
    $('#username').focus(function () {
        $('label[for="username"]').addClass('selected');
    });
    $('#username').blur(function () {
        $('label[for="username"]').removeClass('selected');
    });
    $('#password').focus(function () {
        $('label[for="password"]').addClass('selected');
    });
    $('#password').blur(function () {
        $('label[for="password"]').removeClass('selected');
    });
</script>

</html>

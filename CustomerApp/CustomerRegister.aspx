<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerRegister.aspx.cs" Inherits="CustomerApp.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
		<script type="text/javascript" src="Scripts/ajax/ajax.js"></script>

	<div style="height:100px;"></div>

	<div class="row">
		<div class="col-md-1"></div>
		<div class="col-md-7">
			<h2>Register Customer Details</h2><br />
		</div>


	</div>

	<div class="row">
		<div class="col-md-1"></div>
		<div class="col-md-5">
			<div class="input-group mb-3">
				<div class="input-group-prepend">
					<label class="input-group-text" for="inputGroupSelect01">Tittle</label>
				</div>
				<select class="custom-select" id="inputGroupSelect01">
					<option selected>Choose...</option>
					<option value="0">Mr</option>
					<option value="1">Ms</option>
					<option value="2">Mrs</option>
					<option value="3">Miss</option>
					<option value="4">Dr</option>

				</select>
			</div>

			<div class="input-group mb-3">
				<input type="text" class="form-control" id="txtFirstName" placeholder="First Name" aria-label="Recipient's username" aria-describedby="basic-addon2">
			</div>

			<div class="input-group mb-3">
				<input type="text" class="form-control" id="txtMiddleName" placeholder="Middle Name" aria-label="Recipient's username" aria-describedby="basic-addon2">
			</div>

			<div class="input-group mb-3">
				<input type="text" class="form-control" id="txtLastName" placeholder="Last Name" aria-label="Recipient's username" aria-describedby="basic-addon2">
			</div>

			<div class="input-group mb-3">

				<input type="text" class="form-control" id="txtDOB" placeholder="Date of Birth" aria-label="Recipient's username" aria-describedby="basic-addon2">

			</div>
			<div class="row">
				<div class="col-md-10">
					<div class="input-group mb-3">
						<input id="btnSubmit" class="btn btn-success" type="button" value="Submit" />
					</div>

				</div>


			</div>




		</div>

	</div>
</asp:Content>

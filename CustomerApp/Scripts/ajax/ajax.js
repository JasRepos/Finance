$(document).ready(function () {

	$('#linkClose').click(function () {
		$('#divError').hide('fade');
	});

	$('#btnInput').click(function () {
		$('#divInput').removeClass('hidden');
		$('#tblInput').empty();
	});

	$('#btnClearData').click(function () {
		$('#divData').removeClass('hidden');
		$('#tblBody').empty();
	});

	$('#btnCustomerDetails').click(function () {
		$.ajax({
			url: "http://localhost:15133/api/CustomersTableView/" + $("#txtCustomerId").val(),
			method: 'GET',

			success: function (data, textStatus, jqXHR) {

				$("#inputGroupSelect01").val(data.Title);
				$("#txtFirstName").val(data.ForeName);
				$("#txtMiddleName").val(data.MiddleInitial);
				$("#txtLastName").val(data.SurName);
				$("#txtDOB").val(data.DateofBirth);

			},
			error: function (jqXHR, textStatus, errorThrown) {
				$("#txtCustomerID").val(jqXHR.statusText);
			}


		});
	});

	$('#btnDeleteCustomer').click(function () {
		$.ajax({
			url: "http://localhost:15133/api/CustomersTableView/" + $("#txtCustomerId").val(),
			method: 'DELETE',

			success: function (response) {
				alert("Customer with ID " + $("#txtCustomerId").val() + " Deleted Successfully");
			},
			error: function (jqXHR, textStatus, errorThrown) {
				alert("Error:" + $("#txtCustomerID").val(jqXHR.statusText));
			}


		});
	});

	$(document).ready(function () {
		$("#tblInput").validate({
			rules: {
				txtCustomerId: "required"
			},
			messages: {
				txtCustomerId: "Please specify your name"
			}
		})
	});

	$('#btnUpdateCustomer').click(function () {
		$.ajax({
			url: "http://localhost:15133/api/CustomersTableView/" + $("#txtCustomerId").val(),
			method: 'PUT',
			data: {
				Title: $('#inputGroupSelect01').val(),
				ForeName: $('#txtFirstName').val(),
				MiddleInitial: $('#txtMiddleName').val(),
				SurName: $('#txtLastName').val(),
				DateofBirth: $('#txtDOB').val()

			},

			success: function (response) {
				alert("Details Updated Successfully for Customer with ID " + $("#txtCustomerId").val());
			},
			error: function (jqXHR, textStatus, errorThrown) {
				if ($("#txtCustomerID").val() == null) {
					alert("Please Enter CustomerID");

				} else {
					alert("Error:" + $("#txtCustomerID").val(jqXHR.statusText));
				}
			}


		});
	});

	$(document).ready(function () {

		//Close the bootstrap alert
		$('#linkClose').click(function () {
			$('#divError').hide('fade');
		});

		// Save the new user details
		$('#btnSubmit').click(function () {
			$.ajax({
				url: "http://localhost:15133/api/CustomersTableView/",
				method: 'POST',
				data: {
					Title: $('#inputGroupSelect01').val(),
					ForeName: $('#txtFirstName').val(),
					MiddleInitial: $('#txtMiddleName').val(),
					SurName: $('#txtLastName').val(),
					DateofBirth: $('#txtDOB').val()

				},
				success: function () {
					$('#inputGroupSelect01').val('');
					$('#inputGroupSelect01').val('');
					$('#txtFirstName').val('');
					$('#txtMiddleName').val('');
					$('#txtLastName').val('');
					$('#txtDOB').val('');
					alert(" Customer Registration Successful");
				},
				error: function (jqXHR) {

					alert(jqXHR.responseText);
				}
			});
		});
	});



	$('#btnLoadEmployees').click(function () {
		$.ajax({
			url: "http://localhost:15133/api/CustomersTableView/",
			method: 'GET',

			success: function (data) {
				$('#divData').removeClass('hidden');
				$('#tblBody').empty();
				$.each(data, function (index, value) {
					var tittleVal = value.Title;
					var actualTittle;
					if (tittleVal == 0) { actualTittle = "Mr"; }
					else if (tittleVal == 1) { actualTittle = "Ms"; }
					else if (tittleVal == 2) { actualTittle = "Mrs"; }
					else if (tittleVal == 3) { actualTittle = "Miss"; }
					else if (tittleVal == 4) { actualTittle = "Dr"; }
					else { actualTittle = "null"; }
					var row = $('<tr><td>' + value.CustomerID + '</td><td>'
						+ actualTittle + '</td><td>'
						+ value.ForeName + '</td><td>'
						+ value.MiddleInitial + '</td><td>'
						+ value.SurName + '</td><td>'
						+ value.DateofBirth + '</td></tr>');
					$('#tblData').append(row);
				});
			},

			error: function (jQXHR) {
				$('#divErrorText').text(jqXHR.responseText);
				$('#divError').show('fade');
			}

		});
	});

});


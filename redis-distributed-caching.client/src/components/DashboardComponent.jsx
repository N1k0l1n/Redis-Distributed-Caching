/* eslint-disable no-unused-vars */
import React, { useEffect, useState } from 'react';

function DashboardComponent() {
    const [dashboardData, setDashboardData] = useState(null);

    useEffect(() => {
        // Fetch dashboard data
        fetch('https://localhost:7148/api/Dashboard/dashboard')
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .then(data => {
                setDashboardData(data);
            })
            .catch(error => {
                // Handle errors
                console.error('There was a problem fetching data:', error);
            });
    }, []);

  return (
      <div>
          <h1>Dashboard</h1>
          {dashboardData && (
              <div>
                  <p>Total Customer Count: {dashboardData.totalCustomerCount}</p>
                  <p>Total Revenue: {dashboardData.totalRevenue}</p>
              </div>
          )}
      </div>
  );
}

export default DashboardComponent;
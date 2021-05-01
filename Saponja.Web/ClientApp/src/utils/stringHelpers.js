export const getReadableDate = (dateString) => {
  const date = new Date(dateString);

  const MONTHS_GENITIVE = ["siječnja", "veljače", "ožujka", "travnja", "svibnja",
    "lipnja", "srpnja", "kolovoza", "rujna", "listopada", "studenog", "prosinca"];
  const readableDateString = `${date.getDate()}. ${MONTHS_GENITIVE[date.getMonth()]} ${date.getFullYear()}.`;

  return readableDateString;
}
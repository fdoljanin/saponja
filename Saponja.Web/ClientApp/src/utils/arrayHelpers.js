export const getSequenceFromArray = (array) => {
  return Array(array.length).fill(0).map((e, i) => i);
}

export const getBase32FromArray = (array) => {
  if (!array.length) {
    return "";
  };

  const reducer = (accumulator, currentValue) => (accumulator + Math.pow(2, currentValue));
  const mask = array.reduce(reducer, 0);
  return mask.toString(32);
}

export const getArrayFromBase32 = (base32) => {
  if (!base32) return null;

  let isChosenArray = parseInt(base32, 32).toString(2).split('');
  isChosenArray.reverse();
  const array = isChosenArray.map((e, i) => +e ? i : null).filter(e => e !== null);
  return array.length ? array : null;
};